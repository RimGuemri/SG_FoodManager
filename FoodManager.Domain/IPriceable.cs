namespace FoodManager.Domain;

public interface IPriceable
{
        double CalculatePrice(IEnumerable<IIngredient> ingredientsInfos);
}
