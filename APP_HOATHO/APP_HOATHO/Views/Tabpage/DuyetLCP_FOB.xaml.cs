﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_HOATHO.Views.Tabpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DuyetLCP_FOB : TabbedPage
    {
        public DuyetLCP_FOB()
        {
            InitializeComponent();
            ContentPage navigationPage = new DuyetChungTu.DuyetChungTu_Header(Global.DocumentType.DuyetLCP);
            navigationPage.IconImageSource = "baseline_check_circle_black.png";           
            navigationPage.Title = "Chờ Duyệt";         

            ContentPage  content = new MoLaiChungTu.MoLaiChungTu_Header(Global.DocumentType.MoLaiLCP_FOB);
            content.Title = "Mở Lại";
            content.IconImageSource = "baseline_open_in_browser_black.png";
            Children.Add(navigationPage);
            Children.Add(content );
           
        }
       
        public async Task LoadData()
        {
            DuyetChungTu.DuyetChungTu_Header list = Children[0] as DuyetChungTu.DuyetChungTu_Header;
            list.viewModel.IsBusy = false;
            list.viewModel.LoadCommand.Execute(null);
        }
    }
}