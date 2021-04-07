using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public override double OverallPerformance => base.OverallPerformance + CalculateOverallPerformance();

        public override decimal Price => base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);

        private double CalculateOverallPerformance()
        {
            double performance = 0;
            if (Components.Count > 0)
            {
                performance = components.Average(x => x.OverallPerformance);
            }

            return performance;
        }

        public void AddComponent(IComponent component)
        {
            IComponent componentChecker = components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name);
            if (componentChecker != null)
            {
                throw new ArgumentException(
                    $"Component {componentChecker.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent componentChecker = components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (componentChecker == null)
            {
                throw new ArgumentException(
                    $"Component {componentType} does not exist in {this.GetType().Name} with Id {Id}.");
            }

            components.Remove(componentChecker);
            return componentChecker;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            IPeripheral peripheralChecker = peripherals.FirstOrDefault(x => x.GetType().Name == peripheral.GetType().Name);
            if (peripheralChecker != null)
            {
                throw new ArgumentException(
                    $"Peripheral {peripheralChecker.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheralChecker = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheralChecker == null)
            {
                throw new ArgumentException(
                    $"Component {peripheralType} does not exist in {this.GetType().Name} with Id {Id}.");
            }

            peripherals.Remove(peripheralChecker);

            return peripheralChecker;
        }

        public override string ToString()
        {
            double peripheralsAverage = this.Peripherals.Count > 0 ? this.Peripherals.Average(x => x.OverallPerformance) : 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" Components ({components.Count}):");
            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }
            sb.AppendLine(
                $" Peripherals ({Peripherals.Count}); Average Overall Performance ({peripheralsAverage:f2}):");
            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }


            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }
    }
}
