using System;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace St10090056RecipePOE
{
    public partial class Menu : Window, INotifyPropertyChanged
    {
        private RecipeData recipeData; // Holds the data for recipes
        private ObservableCollection<Recipe> recipes; // Collection of recipes
        private EnterRecipe enterRecipeWindow; // Reference to the EnterRecipe window

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipeData.Recipes; } // Retrieves the recipe collection from recipeData
            set
            {
                recipeData.Recipes = value; // Sets the recipe collection in recipeData
                OnPropertyChanged(nameof(Recipes));
            }
        }

        private ObservableCollection<Ingredient> ingredients;

        public ObservableCollection<Ingredient> GetIngredients1()
        {
            return ingredients;
        }

        private void SetIngredients1(ObservableCollection<Ingredient> value)
        {
            ingredients = value;
        }

        public void SetIngredients(ObservableCollection<Ingredient> value)
        {
            SetIngredients1(value); // Sets the ingredient collection
            OnPropertyChanged(nameof(GetIngredients1()));
        }

        public Menu(RecipeData data)
        {
            InitializeComponent();

            recipeData = data; 
            // Assigns the provided recipe data to the local variable
            recipes = recipeData.Recipes;
            // Retrieves the recipe collection from recipeData
            SetIngredients(new ObservableCollection<Ingredient>());
            // Initializes the Ingredients collection
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void AddRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            enterRecipeWindow = new EnterRecipe(recipeData, enterRecipeWindow); 
            // Creates a new instance of the EnterRecipe window

            enterRecipeWindow.Show(); 
            // Shows the EnterRecipe window
            Close();
            // Closes the current Menu window
        }

        private void DisplayRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeListWindow newRecipeListWindow = new RecipeListWindow(recipeData);
            // Creates a new instance of the RecipeListWindow

            newRecipeListWindow.Show(); 
            // Shows the RecipeListWindow
            Close();
            // Closes the current Menu window
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleQuantitiesWindow scaleWindow = new ScaleQuantitiesWindow(recipeData); 
            // Creates a new instance of the ScaleQuantitiesWindow

            scaleWindow.ShowDialog();
            // Shows the ScaleQuantitiesWindow as a dialog

            // Check if the scaling was successful or canceled
            if (scaleWindow.DialogResult.HasValue && scaleWindow.DialogResult.Value)
            {
                // Refresh the UI to reflect the scaled quantities
                SetIngredients(new ObservableCollection<Ingredient>(GetIngredients1()));
            }

            Close(); 
            // Closes the current Menu window
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecipeWindow obj = new DeleteRecipeWindow(recipeData); 
            // Creates a new instance of the DeleteRecipeWindow

            obj.Show(); 
            // Shows the DeleteRecipeWindow
            Close();
            // Closes the current Menu window
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
            // Exits the application
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class EnterRecipe
    {
        public EnterRecipe(RecipeData recipeData)
        {
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }

    internal class Ingredient
    {
    }
}
