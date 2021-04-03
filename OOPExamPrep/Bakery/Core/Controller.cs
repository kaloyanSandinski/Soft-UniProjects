using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else
            {
                food = new Cake(name, price);
            }

            bakedFoods.Add(food);
            return $"Added {name} ({type}) to the menu";
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            else
            {
                drink = new Tea(name, portion, brand);
            }
            drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table} has been reserved for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table==null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
                if (food==null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    table.OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                }
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IDrink drink = drinks.FirstOrDefault(f => f.Name == drinkName&&f.Brand==drinkBrand);
                if (drink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table==null)
            {
                throw new ArgumentException(string.Format(OutputMessages.WrongTableNumber, tableNumber));
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {table.TableNumber}")
                .AppendLine($"Bill: {table.GetBill():f2}");
            totalIncome += table.GetBill();
            table.Clear();
            return sb.ToString();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables)
            {
                if (table.IsReserved==false)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }
    }
}
