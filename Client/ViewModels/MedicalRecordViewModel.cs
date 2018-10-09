using Client.Models;
using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Client.ViewModels
{
    class MedicalRecordViewModel: ViewModelBase
    {
        
        private List<UAnamnesis> anamnesis;

        public List<UAnamnesis> Anamnesis
        {
            get { return anamnesis; }
            set
            {
                anamnesis = value;
                OnPropertyChanged("Anamnesis");
            }
        }

        public MedicalRecordViewModel()
        {
            try
            {
                using (HealthManagementEntities db = new HealthManagementEntities())
                {
                    anamnesis = db.UAnamnesis.ToList();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
