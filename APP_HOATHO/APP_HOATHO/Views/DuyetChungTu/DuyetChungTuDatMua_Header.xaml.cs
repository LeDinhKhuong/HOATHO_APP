﻿using APP_HOATHO.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP_HOATHO.ViewModels.DuyetChungTu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APP_HOATHO.Models.DuyetChungTu;

namespace APP_HOATHO.Views.DuyetChungTu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DuyetChungTuDatMua_Header : ContentPage
    {
     public    DuyetChungTu_Header_ViewModel viewModel;
        public DuyetChungTuDatMua_Header(DocumentType type) 
        {
            InitializeComponent();
            viewModel = new DuyetChungTu_Header_ViewModel(type);
            viewModel.navigation = Navigation;
            BindingContext = viewModel;
        }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    if (viewModel.ListItem.Count == 0)
        //    {
        //        IsBusy = false;
        //        viewModel.LoadCommand.Execute(null);
        //    }    
        //}
        private void listChiTiet_SelectionChanged(object sender, Syncfusion.SfDataGrid.XForms.GridSelectionChangedEventArgs e)
        {
            DuyetChungTuModel _selectItem = listChiTiet.SelectedItem as DuyetChungTuModel;
            if (_selectItem == null) return;
            if (viewModel._documentType == DocumentType.DuyetDatMuaPhuTung)
                Navigation.PushAsync(new DuyetChungTuPhuTung_Line(_selectItem, viewModel._documentType));
            else
                Navigation.PushAsync(new DuyetChungTu_Line(_selectItem, viewModel._documentType));
        }
    }
}