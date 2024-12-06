using MenuDLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffe_app.logic
{
    /// <summary>
    /// Класс, представляющий пользовательские промоакции.
    /// </summary>
    internal class UserPromotions
    {
        /// <summary>
        /// Список промоакций.
        /// </summary>
        public List<MenuDLL.Promotion> components = new List<MenuDLL.Promotion>();

        Coffee factoryChocolateSyrup = new ChocolateSyrupFactory();
        Coffee factoryBananaSyrup = new BananaSyrupFactory();
        Coffee factoryLavenderSyrup = new LavenderSyrupFactory();
        Coffee factoryRaspberrySyrup = new RaspberrySyrupFactory();
        Coffee factoryCaramelSyrup = new CaramelSyrupFactory();

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UserPromotions"/>.
        /// </summary>
        public UserPromotions()
        {
            List<MenuDLL.Menu> comp = new List<MenuDLL.Menu>();
            comp.Add(factoryRaspberrySyrup.createLatte(true, 3.5, 400));
            comp.Add(new Dessert(4, 75, "Круасан"));
            components.Add(new Promotion("Латте + круасан теперь выгоднее!", comp, 4.9, "01-12-2024", "31-12-2024"));
            comp.Clear();
        }
    }

}
