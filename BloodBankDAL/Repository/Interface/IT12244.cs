using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BloodBankDAL.Repository.Interface
{
    public interface IT1244
    {
       DataTable FormAuthorization(string T_USER_ID, string T_FORM_CODE, string T_ROLE_CODE);
    }
}
