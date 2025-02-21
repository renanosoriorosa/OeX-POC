﻿namespace OeX.Auth.Domain.Common
{
    public abstract class PageList
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
