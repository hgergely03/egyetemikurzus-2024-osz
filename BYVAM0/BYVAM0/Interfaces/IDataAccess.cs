﻿using BYVAM0.Model;

namespace BYVAM0.Interfaces
{
    internal interface IDataAccess
    {
        List<Question>? GetQuestions(string filePath);
    }
}