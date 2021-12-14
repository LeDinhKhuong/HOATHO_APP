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
    public partial class MoLaiChungTuDatMua_Header : ContentPage 
    { 
        MoLaiChungTuDaDuyet_Header_ViewModel viewModel; 
        public MoLaiChungTuDatMua_Header(DocumentType type)  
        {
            InitializeComponent();
            viewModel = new MoLaiChungTuDaDuyet_Header_ViewModel(type);
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
        public bool FilterRecords(object o)
        {

            var item = o as DuyetChungTuModel;

            if (item != null)
            {

                if (item.ExternalDocNo.ToLower().Contains(filterText) )
                    return true;
            }
            return false;
        }
        string filterText;
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterText = e.NewTextValue;
            listChiTiet.View.Filter = FilterRecords;
            listChiTiet.View.RefreshFilter();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            viewModel.DateChangeCommand.Execute(null);
        }

        private void listChiTiet_SelectionChanged(object sender, Syncfusion.SfDataGrid.XForms.GridSelectionChangedEventArgs e)
        {
            DuyetChungTuModel _selectItem = listChiTiet.SelectedItem as DuyetChungTuModel;
            if (_selectItem == null) return;
            Navigation.PushAsync(new MoLaiChungTuDatMua_Line(_selectItem, viewModel._documentType));
        }
    }
}