using BusinessLogic;
using lab_1;
using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWinForms;

namespace Presenter
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            ILogic logic = ninjectKernel.Get<ILogic>();

            int choice = 0;
            bool valid = false;

            Console.Write("Выберите вариант приложения:\n[1.] WnForms\n[2.] Консоль\nВвод: ");

            while (!valid)
            {
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("\n\tОшибка ввода, попробуйте снова\nВвод: ");
                }
                else valid = true;
            }

            switch (choice)
            {
                case 1:
                    MainForm mainView = new MainForm();
                    IAddView addView = new AddForm();
                    IChangeView changeView = new ChangeForm();
                    ISearchByIdView searchByIdView = new SearchByIdForm();
                    IFindByOriginView findByOriginView = new FindByOriginForm();
                    IGroupedByBodyPartsView groupedByBodyPartsView = new GroupedByBodyPartsForm();

                    mainView.AddBtnClickEvent += (e) => addView.ShowDialogView();
                    mainView.GetByIdBtnClickEvent += searchByIdView.ShowDialogView;
                    mainView.GroupByBodyPartClickEvent += groupedByBodyPartsView.ShowDialogView;
                    mainView.FindByOriginBtnClickEvent += (e) => findByOriginView.ShowDialogView();

                    mainView.ChangeBtnClickEvent += (e) =>
                    {
                        var prosthesis = logic.GetProsthesisById(e.Id);
                        if (prosthesis == null) return;

                        var prosDto = new ProsthesisDTO(prosthesis.Id, prosthesis.ModelName, prosthesis.BodyPart, prosthesis.PercentOfSanityLoss, 
                            prosthesis.BuffDescription, prosthesis.DebuffDescription, prosthesis.Origin);

                        new ChangePresenter(changeView, logic, prosDto);
                        changeView.ShowDialogView();
                    };

                    new MainPresenter(mainView, logic);
                    new AddPresenter(addView, logic);
                    new SearchByIdPresenter(searchByIdView, logic);
                    new FindByOriginPresenter(findByOriginView, logic);
                    new GroupedByBodyPartsPresenter(groupedByBodyPartsView, logic);

                    Application.Run(mainView);
                    break;

                case 2:
                    ConsoleView consoleView = new ConsoleView();
                    new MainPresenter(consoleView, logic);

                    consoleView.LoadBodyPartsList(logic.GetBodyPartsList());
                    consoleView.LoadOriginList(logic.GetOriginList());

                    consoleView.ConsoleMain();
                    break;
            }
        }
    }
}
