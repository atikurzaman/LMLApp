using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMLApp
{
   public class InvokeOperation
    {
        public enum Type
        {
            /// <summary>
            /// INSERT
            /// </summary>
            IN,
            /// <summary>
            /// UPDATE
            /// </summary>
            UP,
            /// <summary>
            /// Delete
            /// </summary>
            DL,
            /// <summary>
            /// Table Schema
            /// </summary>
            TS,
            /// <summary>
            /// SELECT All
            /// </summary>            
            SE,
            /// <summary>
            /// Select with filtered Column and where condition.
            /// </summary>
            SC,
            /// <summary>
            /// Custom query. 
            /// </summary>
            CQ,
            /// <summary>
            /// Get single row by ID. [@Action = GS, ID = objecyID]
            /// </summary>
            GS,
            /// <summary>
            /// Get Data List with Where condition
            /// </summary>
            GW,
            /// <summary>
            /// Complex Transaction process
            /// </summary>
            TN
        }
    }
}
