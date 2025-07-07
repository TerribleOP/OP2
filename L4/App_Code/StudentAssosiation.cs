using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4.App_Code
{
	public class StudentAssociation : IEnumerable<Question>
    {

		public string name { get; set; }


        private List<Question> Questions;

        public StudentAssociation()
        {
            Questions = new List<Question>();
        }

        public StudentAssociation(string name)
        {
            this.name = name;
            Questions = new List<Question>();
        }

        /// <summary>
        /// Add a question to the list of questions
        /// </summary>
        /// <param name="question"></param>
        public void Add(Question question)
        {
            Questions.Add(question);            
        }
        /// <summary>
        /// Count the number of questions in the list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Questions.Count();
        }

        /// <summary>
        /// Get the list of questions
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Question Get(int index)
        {
            try
            {
                return Questions[index];
            }
            catch
            { 
                return null; 
            }
        }



        public IEnumerator<Question> GetEnumerator()
        {
            return Questions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}