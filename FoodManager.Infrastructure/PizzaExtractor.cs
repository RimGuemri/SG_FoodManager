namespace FoodManager.Infrastructure;

using ClosedXML.Excel;
using FoodManager.Domain;

public class PizzaExtractor
{
     internal static (IEnumerable<IFood>,IEnumerable<IIngredient>) ExtractData(XLWorkbook workbook)
        {
            return (GetPizzas(workbook),GetIngredients(workbook));
        }

        private static IEnumerable<IIngredient> GetIngredients(XLWorkbook workbook)
        {
            List<Ingredient> Ingredients = new List<Ingredient>();
            //TODO
            return Ingredients;
        }

        private static List<Pizza> GetPizzas(XLWorkbook workbook)
        {            
            List<Pizza> Pizzas = new List<Pizza>();
            //TODO
            return Pizzas;
        }
}
    