using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterFeastClient.Models;

namespace MonsterFeastClient.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        // Properties
        private Player _CurrentPlayer;
        public Player CurrentPlayer
        {
            get { return _CurrentPlayer; }
            set
            {
                if (value != _CurrentPlayer)
                {
                    _CurrentPlayer = value;
                    RaisePropertyChanged("CurrentPlayer");
                }
            }
        }
        private bool _IsAuthenticated;
        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set
            {
                if (value != _IsAuthenticated)
                {
                    _IsAuthenticated = value;
                    RaisePropertyChanged("IsAuthenticated");
                    RaisePropertyChanged("IsNotAuthenticated");
                }
            }
        }

        public bool IsNotAuthenticated
        {
            get
            {
                return !IsAuthenticated;
            }
        }

        public bool CanDoAuthenticated(object ignore)
        {
            return IsAuthenticated;
        }


        // Constructor
        public AuthViewModel()
        {
            CurrentPlayer = new Player { Username="radit" , Password="Password"};
        }

        // Method
        public void Authenticate()
        {
            IsAuthenticated = true;
        }

        public void Logout()
        {
            IsAuthenticated = false;
        }
    }
}
