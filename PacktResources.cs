using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace WorkingWithCultures
{
    public class PacktResources
    { 
        private readonly IStringLocalizer<PacktResources> localizer = null!;
        public PacktResources(IStringLocalizer<PacktResources> localizer)
        {
            this.localizer = localizer;
        }
        public string? GetEnterYourNamePrompt()
        {
            string resourceStringName = "EnterYourName";
             LocalizedString localizedString = localizer[resourceStringName];
              if (localizedString.ResourceNotFound)
              {
                ConsoleColor previousColor = ForegroundColor;
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"Error: resource string \"{resourceStringName}\" not found."
                  + Environment.NewLine
                  + $"Search path: {localizedString.SearchedLocation}");
                ForegroundColor = previousColor;
                return $"{localizedString}: ";
              }
             return localizedString;
        }
        public string? GetEnterYourDobPrompt()
        {
             return localizer["EnterYourDob"];
        }
        public string? GetEnterYourSalaryPrompt()
        {
            return localizer["EnterYourSalary"];
        }
        public string? GetPersonDetails(
          string name, DateTime dob, int minutes, decimal salary)
        {
            return localizer["PersonDetails", name, dob, minutes, salary];
        }
    }
}
