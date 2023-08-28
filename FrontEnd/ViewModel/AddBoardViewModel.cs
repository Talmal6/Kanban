using FrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.ViewModel
{
    public class AddBoardViewModel : NotifableObject
    {
        private BackendController controller;
        private string boardName;
        private string creator;
        private string errorMsg;
        private bool isDialogOpen = false;
        private BoardListViewModel ABVM;

        public string BoardName { get => boardName; set => boardName = value; }
        public string Creator { get => creator; set => creator = value; }
        public string ErrorMsg { get => errorMsg; set { errorMsg = value; RaisePropertyChanged(nameof(ErrorMsg)); } }
        public bool IsDialogOpen { get => isDialogOpen; set { isDialogOpen = value; RaisePropertyChanged(nameof(IsDialogOpen)); } }

        public AddBoardViewModel(BackendController controller, BoardListViewModel _ABVM)
        {
            this.controller = controller;
            this.ABVM = _ABVM;
        }

        public bool AddBoard(string email)
        {
            try
            {
                controller.AddBoard(email, boardName);
                int id;

                if (int.TryParse(controller.GetBoardId(email, boardName), out id))
                {
                    BoardModel board = new BoardModel(controller, id, email);
                    ABVM.Boards.Add(board);
                }

                return true;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return false;
            }       
        }
    }
}
