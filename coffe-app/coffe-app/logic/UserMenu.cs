using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuDLL;

namespace coffe_app.logic
{
    internal class UserMenu
    {
        public List <MenuDLL.Menu> components = new List <MenuDLL.Menu> ();

        Coffee factoryChocolateSyrup = new ChocolateSyrupFactory();
        Coffee factoryBananaSyrup = new BananaSyrupFactory();
        Coffee factoryLavenderSyrup = new LavenderSyrupFactory();
        Coffee factoryRaspberrySyrup = new RaspberrySyrupFactory();
        Coffee factoryCaramelSyrup = new CaramelSyrupFactory();

        UserMenu()
        {
            components.Add(factoryChocolateSyrup.createAmericano(true, 3, 200));
            components.Add(factoryChocolateSyrup.createCappuccino(true, 4, 500));
            components.Add(factoryChocolateSyrup.createRaf(true, 5, 600));

            components.Add(factoryBananaSyrup.createFlatWhite(true, 4, 400));
            components.Add(factoryBananaSyrup.createLatte(true, 5.5, 500));
            components.Add(factoryBananaSyrup.createRaf(true, 5, 500));

            components.Add(factoryLavenderSyrup.createAmericano(true, 4, 400));
            components.Add(factoryLavenderSyrup.createFlatWhite(true, 3.5, 300));
            components.Add(factoryLavenderSyrup.createLatte(true, 5, 600));

            components.Add(factoryRaspberrySyrup.createCappuccino(true, 5, 500));
            components.Add(factoryRaspberrySyrup.createLatte(true, 3.5, 400));
            components.Add(factoryRaspberrySyrup.createRaf(true, 4, 500));

            components.Add(factoryCaramelSyrup.createFlatWhite(true, 4.5, 500));
            components.Add(factoryCaramelSyrup.createLatte(true, 5, 600));
            components.Add(factoryCaramelSyrup.createRaf(true, 4, 300));

            components.Add(new TeaWithoutSyrup(true, 2, 300));
            components.Add(new TeaWithChocolateSyrup(true, 2.5, 300));
            components.Add(new TeaWithLavenderSyrup(true, 2.5, 300));
            components.Add(new TeaWithRaspberrySyrup(true, 2.5, 300));
            components.Add(new TeaWithCaramelSyrup(true, 2.5, 300));

            components.Add(new LemonadeWithoutSyrup(true, 4, 400));
            components.Add(new LemonadeWithChocolateSyrup(true, 4.5, 400));
            components.Add(new LemonadeWithLavenderSyrup(true, 4.5, 400));
            components.Add(new LemonadeWithRaspberrySyrup(true, 4.5, 400));
            components.Add(new LemonadeWithCaramelSyrup(true, 4.5, 400));

            components.Add(new Dessert(5, 150, "Круассан с шоколадом"));
            components.Add(new Dessert(6, 100, "Тарталетки"));
            components.Add(new Dessert(7.5, 300, "Чизкейк"));
            components.Add(new Dessert(4, 50, "Пончик в гразури"));
            components.Add(new Dessert(4.5, 75, "Пирожное картошка"));
        }
    }
}
