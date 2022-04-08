using SnakeGame.Base;


namespace SnakeGame
{
    public class MainController : BaseController
    {
        private readonly MainModel mainModel;

        public MainController(MainModel mainModel)
        {
            this.mainModel = mainModel;
        }
    }
}