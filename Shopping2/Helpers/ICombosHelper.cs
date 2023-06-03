using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping2.Data.Entities;

namespace Shopping2.Helpers
{
	public interface ICombosHelper
	{
		Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync();

        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync(IEnumerable<Category> filter);

        Task<IEnumerable<SelectListItem>> GetComboCountriesAsync();

		Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId);

		Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);

	}
}
