﻿using System.Reactive;
using CodeBucket.Core.Data;
using ReactiveUI;

namespace CodeBucket.Core.ViewModels.Accounts
{
    public class AccountItemViewModel : ReactiveObject, ICanGoToViewModel
    {
        private bool _selected;
        public bool IsSelected
        {
            get { return _selected; }
            internal set { this.RaiseAndSetIfChanged(ref _selected, value); }
        }

        public string Username { get; }

        public string AvatarUrl { get; }

        public string Domain { get; }

        public ReactiveCommand<Unit, Unit> DeleteCommand { get; } = ReactiveCommand.Create(() => { });

        public ReactiveCommand<Unit, Unit> GoToCommand { get; } = ReactiveCommand.Create(() => { });

        internal AccountItemViewModel(Account account)
        {
            Username = account.Username;
            AvatarUrl = account.AvatarUrl;
            Domain = account.Domain;
        }
    }
}

