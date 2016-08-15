using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Cbd.Fgw.Application.PagedResult {
    /// <summary>
    /// 分页数据输出载体 for bootstrap.table.js
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataTableViewModelOutput<T> : IOutputDto where T : class, new() {
        /// <summary>
        /// 总行数
        /// </summary>
        int Total { set; get; }
        /// <summary>
        /// 数据内容
        /// </summary>
        List<T> Rows { set; get; }
    }
}
