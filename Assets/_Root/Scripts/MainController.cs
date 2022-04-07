
namespace SnakeGame
{
    internal class MainController : BaseController
    {
        private readonly MainModel mainModel;

        public MainController(MainModel mainModel)
        {
            this.mainModel = mainModel;
        }
    }
}