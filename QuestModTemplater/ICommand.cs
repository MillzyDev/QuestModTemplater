using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestModTemplater
{
    // command interface
    interface ICommand
    {
        public String getName();
        public String getDescription();

        public void handle();

    }
}
