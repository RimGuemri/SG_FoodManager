namespace FoodManager.Infrastructure;

using ClosedXML.Excel;
using FoodManager.Domain;

public class ExcelDataLoader : IDataLoader
{
    private readonly string _filePath;

    public ExcelDataLoader(string filePath)
    {
        _filePath = filePath;
    }

    public static (IEnumerable<IFood>,IEnumerable<IIngredient>) LoadData(string filePath, FoodType foodType)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Fichier introuvable.");

            using (var workbook = new XLWorkbook(filePath))
            {
                switch(foodType)
                {
                    case FoodType.PIZZA:
                        return PizzaExtractor.ExtractData(workbook);
                    case FoodType.BURGER:
                    default:
                    throw new ArgumentException("Food type not supported");

                }
            }
        }
}