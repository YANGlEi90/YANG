using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T6_1_1
{
    public class ClassManager
    {
        public List<ClassMessage> FindClass()
        {
            List<ClassMessage> list = new List<ClassMessage>() {
                new ClassMessage(){ classID=1,classNeme="2018173801班"},
                new ClassMessage(){ classID=2,classNeme="2018173802班"},
                new ClassMessage(){ classID=3,classNeme="2018173803班"}
            };
            return list;
        }
    }
}