using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMLApp;

/// <summary>
///*************************************************************
///Created By    : Saba Sabrin
///Creation Date : 12.01.2010
///Name          : Customer.cs
///Purpose       : Core Class of "Setup_tblCustomer" table
///*************************************************************
///*************************************************************
///Modified By   : 
///Modified Date : 
///*************************************************************
/// </summary>

namespace LMLAPP.MLMCore
{
    public class Customer : CoreBase
    {
        #region Constructors

        public Customer()
        {
            _ProcedureName = StoredProcedure.Name.Setup_SPCustomer;
            Action = InvokeOperation.Type.SE;
        }

        #endregion Constructors

        #region "Private Variables"

        private string _CustomerID;
        private string  _SponsorID;
        private int? _ActivityStatusID;
        private string _ActivityStatus;
        private string _AgentID;       
        private string _CustomerName;
        private string _FatherName;
        private string _MotherName;       
        private string _Sex;
        private string _MailingAddress;
        private string _PermanentAddress;
        private int? _City;
        private string _Country;       
        private string _Zip;
        private string _CellNo;
        private string _Phone;
        private string _Fax;
        private string _Email;
        private DateTime? _DOB;      
        private string _NationalID;
        private DateTime? _RegistrationDate;       
        private bool _IsEmailEnabled;
        private bool _IsWebEnabled;
        private bool _IsSMSEnabled;
        private string _Notes;       
        
        private IList<Customer> _CustomerList;

        #endregion

        #region "Properties"

        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public string SponsorID
        {
            get { return _SponsorID; }
            set { _SponsorID = value; }
        
        }
      
  
        public string ActivityStatus
        {
            get { return _ActivityStatus; }
            set { _ActivityStatus = value; }
        }

   
        public string AgentID
        {
            get { return _AgentID; }
            set { _AgentID = value; }
        }

      

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        public string FatherName
        {
            get { return _FatherName; }
            set { _FatherName = value; }
        }

        public string MotherName
        {
            get { return _MotherName; }
            set { _MotherName = value; }
        }

     

        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        public string MailingAddress
        {
            get { return _MailingAddress; }
            set { _MailingAddress = value; }
        }

        public string PermanentAddress
        {
            get { return _PermanentAddress; }
            set { _PermanentAddress = value; }
        }

        public int? City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

    

        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }


        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

    

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public DateTime? DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

     

        public string NationalID
        {
            get { return _NationalID; }
            set { _NationalID = value; }
        }

        public DateTime? RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }

  
      

        public bool IsEmailEnabled
        {
            get { return _IsEmailEnabled; }
            set { _IsEmailEnabled = value; }
        }

        public bool IsWebEnabled
        {
            get { return _IsWebEnabled; }
            set { _IsWebEnabled = value; }
        }

        public bool IsSMSEnabled
        {
            get { return _IsSMSEnabled; }
            set { _IsSMSEnabled = value; }
        }

    


        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        public IList<Customer> CustomerList
        {
            get { return _CustomerList; }
            set { _CustomerList = value; }
        }

        #endregion
    }
}
