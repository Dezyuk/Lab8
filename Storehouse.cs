using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab8
{
    /// <summary>
    /// Storehouse — класс для управления запасными частями в складе.
    /// </summary>
    public class Storehouse
    {
        private List<PartsWarehouse> _warehouseList;
        //List<PartsWarehouse> warehouseList = new List<PartsWarehouse>();

        public Storehouse(List<PartsWarehouse> list) 
        {
            WarehouseList = list;
        }
        public Storehouse()
        {
            WarehouseList = new List<PartsWarehouse>();
        }
        public List<PartsWarehouse> WarehouseList 
        {
            get => _warehouseList; 
            set => _warehouseList = (value is null ? new List<PartsWarehouse>() : value); 
        }






        /// <summary>
        /// Добавление новой запчасти в List.
        /// </summary>
        /// <param name="newPart">Новая деталь которую необходимо добавить, проверяется есть ли уже данный объект в List через проверку Id.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AddParts(PartsWarehouse newPart)
        {
            if (newPart is not null)
            {
                foreach (PartsWarehouse part in WarehouseList)
                {
                    if (part.Id.Equals(newPart.Id))
                    {
                        throw new ArgumentOutOfRangeException("This part is already in Storage!");
                    }
                }
                WarehouseList.Add(newPart);
            }
            else
            {
                Console.WriteLine(newPart);
                throw new ArgumentOutOfRangeException("This part is already in Storage!");
            }
        }

        /// <summary>
        /// Удаление запчасти из List.
        /// </summary>
        /// <param name="partToRemove">Деталь которую необходимо удалить.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemovePart(PartsWarehouse partToRemove)
        {
            if (partToRemove is not null && WarehouseList.Contains(partToRemove))
            {
                WarehouseList.Remove(partToRemove);
            }
            else
            {
                throw new ArgumentOutOfRangeException("This part does not exist!");
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (PartsWarehouse part in WarehouseList)
            {
                str.Append(part + "\n");
            }
            return str.ToString();
        }
    }
}
