﻿using DMSkin;
using DMSkin.WPF;
using DMSkin.WPF.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Client.ViewModels
{
    public class StartWindowViewModel:ViewModelBase
    {
        private Color _DMWindowShadowColor;

        /// <summary>
        /// 窗体阴影颜色
        /// </summary>
        public Color DMWindowShadowColor
        {
            get { return _DMWindowShadowColor; }
            set
            {
                _DMWindowShadowColor = value;
                OnPropertyChanged("DMWindowShadowColor");
            }
        }

        public ICommand ChangeWindowCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    DMWindowShadowColor = (Color)ColorConverter.ConvertFromString(obj.ToString());
                });
            }
        }

        public ICommand OpenLinkCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (obj is string url)
                    {
                        Process.Start(url);
                    }
                });
            }
        }
    }
}
