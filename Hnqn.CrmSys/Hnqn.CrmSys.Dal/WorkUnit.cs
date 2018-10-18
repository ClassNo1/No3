using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hnqn.CrmSys.Models;


namespace Hnqn.CrmSys.Dal
{
    public class WorkUnit
    {
        private CrmDbContext db;
        public CrmDbContext DB { get { return this.db; } }
        public WorkUnit()
        {
            this.db =  ContextSceond.GetContext();
        }

        private CommonRepository<UserType> _userType;

        public CommonRepository<UserType> UserType
        {
            get
            {
                return _userType ?? new CommonRepository<Models.UserType>(DB);
            }
        }
        private CommonRepository<UserInfo> _userInfo;

        public CommonRepository<UserInfo> UserInfo
        {
            get
            {
                return _userInfo ?? new CommonRepository<Models.UserInfo>(DB);
            }
        }
        private CommonRepository<Professiona> _professiona;

        public CommonRepository<Professiona> Professiona
        {
            get
            {
                return _professiona ?? new CommonRepository<Models.Professiona>(DB);
            }
        }
        private CommonRepository<Recording> _recording;

        public CommonRepository<Recording> Recording
        {
            get
            {
                return _recording ?? new CommonRepository<Models.Recording>(DB);
            }
        }
        private CommonRepository<UserStatus> _userStatus;

        public CommonRepository<UserStatus> UserStatus
        {
            get
            {
                return _userStatus ?? new CommonRepository<Models.UserStatus>(DB);
            }
        }
        private CommonRepository<CustomerInfo> _customerInfo;

        public CommonRepository<CustomerInfo> CustomerInfo
        {
            get
            {
                return _customerInfo ?? new CommonRepository<Models.CustomerInfo>(DB);
            }
        }
        private CommonRepository<SchoolInfo> _schoolInfo;

        public CommonRepository<SchoolInfo> SchoolInfo
        {
            get
            {
                return _schoolInfo ?? new CommonRepository<Models.SchoolInfo>(DB);
            }
        }
        private CommonRepository<SourceInfo> _sourceInfo;

        public CommonRepository<SourceInfo> SourceInfo
        {
            get
            {
                return _sourceInfo ?? new CommonRepository<Models.SourceInfo>(DB);
            }
        }
        public void Save()
        {
            DB.SaveChanges();
        }
    }
}