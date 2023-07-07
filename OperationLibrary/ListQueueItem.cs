using System;
using System.Collections.Generic;
using System.Configuration;

namespace OperationLibrary
{
    public class ListQueueItem
    {
        public List<QueueItem> ListOfItem = new List<QueueItem>();
        private static readonly decimal MAX_VALUE = Decimal.Parse(ConfigurationManager.AppSettings["MAX_VALUE"]);

        public ListQueueItem()
        {
            ListOfItem.Add(new QueueItem());
        }

        public void AddItem(string code, int quantity, decimal price)
        {

            for (int i = 1; i <= quantity; i++)
            {
                decimal inStock = ListOfItem[ListOfItem.Count - 1].CounterPrice + (price * i);

                if (quantity == 1)
                {
                    if(inStock >= MAX_VALUE)
                    {
                        ListOfItem.Add(new QueueItem());
                        QueueNewItem(code, i, price * i);
                    }
                    else
                    {
                        QueueNewItem(code, i, price * i );
                    }
                    break;
                }
                else
                {
                    if (inStock >= MAX_VALUE)
                    {
                        QueueNewItem(code, i - 1, price * (i - 1));
                        ListOfItem.Add(new QueueItem());
                        quantity -= i - 1;
                        i = 0;
                    }

                    if (i + 1 == quantity)
                    {
                        QueueNewItem(code, i + 1, price * (i + 1));
                        break;
                    }
                }
            }
        }

        public void QueueNewItem(string code, int quantity, decimal price)
        {
            ListOfItem[ListOfItem.Count - 1].Data.Rows.Add(code, quantity);
            ListOfItem[ListOfItem.Count - 1].CounterPrice += price;
        }

    }
}
