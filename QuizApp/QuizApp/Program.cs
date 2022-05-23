using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp
{
    public class Program
    {
        class Question
        {
            public Question(string text, string[] choices, string anwer)
            {
                this.Text = text;
                this.Choices = choices;
                this.Answer = anwer;
            }
            public string Text { get; set; }
            public string[] Choices { get; set; }
            public string Answer { get; set; }
            public bool CheckAnswer(string answer)
            {
                return this.Answer.ToLower() == answer.ToLower();
            }
        }
        class Quiz
        {
            public Quiz(Question[] questions)
            {
                this.Questions = questions;
            }
            private Question[] Questions { get; set; }
            private int QuestionIndex { get; set; }
            private int Score { get; set; }

            private Question GetQuestion()
            {
                return this.Questions[this.QuestionIndex];
            }
            private void DisplayProgress()
            {
                int totalQuestion = this.Questions.Length;
                int questionNumber = this.QuestionIndex + 1;

                if (totalQuestion != 0)
                {
                    Console.WriteLine($"Question : {questionNumber} of {totalQuestion}");
                }

            }

            public void DisplayQuestion()
            {
                var question = this.GetQuestion();

                this.DisplayProgress();

                Console.WriteLine($"{this.QuestionIndex + 1}. Question : {question.Text} ");

                foreach (var c in question.Choices)
                {
                    Console.WriteLine($"-{c}");
                }
                Console.WriteLine("Answer : ");
                var result = Console.ReadLine();
                this.Guess(result);
            }
            private void DisplayScore()
            {
                Console.WriteLine($"Score : {this.Score}");
            }
            private void Guess(string result)
            {
                var question = this.GetQuestion();
                if (question.CheckAnswer(result))
                {
                    this.Score++;
                }

                this.QuestionIndex++;

                if (this.Questions.Length == this.QuestionIndex)
                {
                    this.DisplayScore();
                }
                else
                {
                    this.DisplayQuestion();
                }
            }


        }


        public static void Main(string[] args)
        {
            var q1 = new Question("1 + 1", new string[] { "2", "5", "1", "12" }, "2");
            var q2 = new Question("1 * 1", new string[] { "1", "5", "10", "12" }, "1");
            var q3 = new Question("1 / 1", new string[] { "2", "5", "1", "12" }, "1");
            var q4 = new Question("1 - 1", new string[] { "2", "5", "1", "0" }, "0");

            var questions = new Question [] { q1, q2, q3, q4 };
            var quiz = new Quiz(questions);
            quiz.DisplayQuestion();
        }

    }
}
