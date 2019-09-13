﻿using model.Shared.UintaPine;
using System;

namespace app.UintaPine.Services
{
    public class AppState
    {
        private UserSlim _user { get; set; }
        public UserSlim User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                NotifyStateChanged();
            }
        }

        private bool _isInitialized { get; set; } = false;
        public bool IsInitialized
        {
            get
            {
                return _isInitialized;
            }
            set
            {
                _isInitialized = value;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
