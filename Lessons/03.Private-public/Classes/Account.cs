using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes
{
    internal class Account
    {
        private string name; 
        public void SetName(string accountName)
        {
            name = accountName; 
        }
        public string GetName()
        {
            return name; 
        }

	}
	//public void SetName(string acaountaem)
	//{

	//    Name = acaountaem;
	    //{

	//        ;
	//    }
	//}
	//burada kaç tane farklı ıdentfyer var
	//uml clas diagram
	//    public void hetName(string acaountaem)
	/*
		-name: string
		--------------
		+SetName(acountName:String)
		+GetName():string

		+<<property>>Name : string
							guid olursa ne olucak ?


	*/

}
