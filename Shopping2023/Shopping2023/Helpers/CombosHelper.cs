using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Shopping2023.Data;
using System.Drawing.Text;

namespace Shopping2023.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync()
        {

            List<SelectListItem> list = await _context.Categories.Select
                (x => new SelectListItem
                    {
                        Text= x.Name,
                        Value =$"{x.Id}"
                    })
                    .OrderBy(x => x.Text)                
                    .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text="[Seleccione una categoría...]",
                Value="0"
            });
            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId)
        {
            List<SelectListItem> list = await _context.Cities
                .Where(x => x.State.Id==stateId)
                .Select(
                x => new SelectListItem
                {
                    Text= x.Name,
                    Value =$"{x.Id}"
                })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0,new SelectListItem{
               Text="[Selecciona una ciudad...]",
               Value="0"
                
            });
            return list;

        }

        public async Task<IEnumerable<SelectListItem>> GetComboCountriesAsync()
        {

            List<SelectListItem> list = await _context.Countries
                .Select( x=> new SelectListItem
                {
                    Text= x.Name,
                    Value=$"{x.Id}"
                })
                .OrderBy(x =>x.Text)
                .ToListAsync();


            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccion un país...]",
                Value = "0"

            });

            return list; 
        }



        public async Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId)
        {
            List<SelectListItem> list = await _context.States
                .Where(x => x.Country.Id == countryId)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = $"{x.Id}"
                })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text ="[Seleccione un departamento/estado...]",
                Value = "0"

            });
            return list;
        }
    }
}
