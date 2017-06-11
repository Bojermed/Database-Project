using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_reports
{
    public class JsonReportsCreator
    {
        private readonly ICollection<Spaceship> Spaceships;
        private readonly ICollection<ProductSale> Sales;
        private readonly ICollection<ProductReport> Reports;

        public void JsonReportsHandler(ICollection<Spaceship> spaceships, ICollection<ProductSale> sales, ICollection<ProductReport> reports)
        {
            this.Spaceships = spaceships;
            this.Sales = sales;
            this.Reports = reports;
            PopulateReportsList();
        }

        public void WriteReportsToJson(string resultFilesPath)
        {
            foreach (var report in this.Reports)
            {
                var json = JsonConvert.SerializeObject(report, Formatting.Indented);
                File.WriteAllText($"{resultFilesPath}{report.Id}.json", json);
            }
        }

        public ICollection<string> GetReportsInJsonFormat()
        {
            var reports = new List<string>();

            foreach (var report in this.Reports)
            {
                var json = JsonConvert.SerializeObject(report, Formatting.Indented);
                reports.Add(json);
            }

            return reports;
        }

        private void PopulateReportsList()
        {
            foreach (var ship in this.Spaceships)
            {
                var quantity = this.Sales
                    .Where(s => s.ProductName == ship.Model)
                    .Sum(s => s.Quantity);

                var totalSum = this.Sales
                    .Where(s => s.ProductName == ship.Model)
                    .Sum(s => s.Sum);

                var jsonReportEntry = new ProductReport()
                {
                    Id = ship.Id,
                    Model = ship.Model,
                    Category = ship.Category.Name,
                    Price = ship.Price,
                    QuanitySold = quantity,
                    TotalIncome = totalSum
                };

                this.Reports.Add(jsonReportEntry);
            }
        }
    }
}
}
