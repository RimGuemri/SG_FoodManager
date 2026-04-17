namespace FoodManager.Domain.Tests;
using FoodManager.Domain;
using Xunit;


public class PizzaTests
{
    [Fact]
    public void CalculatePrice_ShouldReturnTotalSum_WhenIngredientsExist()
    {
        var pizza = new Pizza { Name = "Reine" };
        pizza.Ingredients = "Tomate,Fromage"; 

        var mockIngredients = new List<IIngredient>
        {
            new Ingredient { Name = "Tomate", Price = 1.5 },
            new Ingredient { Name = "Fromage", Price = 2.0 },
            new Ingredient { Name = "Chorizo", Price = 3.0 }
        };

        var total = pizza.CalculatePrice(mockIngredients);

        Assert.Equal(3.5, total); // 1.5 + 2.0
    }

    [Fact]
    public void CalculatePrice_ShouldThrowException_WhenIngredientIsMissing()
    {
        // ARRANGE
        var pizza = new Pizza { Name = "Inconnue" };
        pizza.Ingredients = "Ananas"; 
        
        var mockIngredients = new List<IIngredient>
        {
            new Ingredient { Name = "Tomate", Price = 1.5 }
        };

        var exception = Assert.Throws<Exception>(() => pizza.CalculatePrice(mockIngredients));
        Assert.Contains("n'est pas présent dans la liste", exception.Message);
    }
}