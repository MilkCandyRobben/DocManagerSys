using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文献管理系统
{
    #region//文章article的xml示例,里面有作者信息
    //<article mdate = "2018-01-07" key="tr/meltdown/s18" publtype="informal">
    //<author>Paul Kocher</author>
    //<author>Daniel Genkin</author>
    //<author>Daniel Gruss</author>
    //<author>Werner Haas</author>
    //<author>Mike Hamburg</author>
    //<author>Moritz Lipp</author>
    //<author>Stefan Mangard</author>
    //<author>Thomas Prescher 0002</author>
    //<author>Michael Schwarz 0001</author>
    //<author>Yuval Yarom</author>
    //<title>Spectre Attacks: Exploiting Speculative Execution.</title>
    //<journal>meltdownattack.com</journal>
    //<year>2018</year>
    //<ee>https://spectreattack.com/spectre.pdf</ee>
    //</article>
    #endregion

    /// <summary>
    /// Created by lb 2020.3.29
    /// 作者实体类(目前重要)
    /// </summary>
    /// 
    class Author_entity
    {
        public string name { set; get; }//作者名称(重要)
        public List<string> literatures { set; get; }//所著文献列表(重要)
        public List<string> collaborators { set; get; }//合作者列表(也许有用)

        /// <summary>
        /// 作者的构造函数
        /// </summary>
        /// <param name="name">作者名称</param>
        /// <param name="articles">文章名称列表</param>
        /// <param name="collaborators">合作者名称列表</param>
        public Author_entity(string name, List<string> literatures, List<string> collaborators = null)
        {
            this.name = name;
            this.literatures = literatures;
            this.collaborators = collaborators;
        }

        /// <summary>
        /// 为作者添加文章,添加1个/多个
        /// </summary>
        public void addArticle(string literature)
        {
            if (literatures == null)
            {
                literatures = new List<string>();
            }
            this.literatures.Add(literature);
            this.literatures = this.literatures.Distinct().ToList();//Distinct去重
        }
        public void addArticles(List<string> literatures)
        {
            this.literatures.Union(literatures);//Union取并集,去重
        }
        public void addArticles(string[] literatures)
        {
            this.literatures.Union(new List<string>(literatures));//Union取并集,去重
        }

        /// <summary>
        /// 为作者添加合作者,添加1个/多个
        /// </summary>
        public void addCollaborator(string collaborator)
        {
            if (collaborators == null)
            {
                collaborators = new List<string>();
            }
            this.collaborators.Add(collaborator);
            this.collaborators = this.collaborators.Distinct().ToList();//Distinct去重
        }
        public void addCollaborators(List<string> collaborators)
        {
            this.collaborators.Union(collaborators);//Union取并集,去重
        }
        public void addCollaborators(string[] collaborators)
        {
            this.collaborators.Union(new List<string>(collaborators));//Union取并集,去重
        }

        /// <summary>
        /// 获取该作者的文章数
        /// </summary>
        /// <returns></returns>
        int getArticleCount()
        {
            return this.literatures.Count();
        }

        /// <summary>
        /// 判断文章是否在该作者的文章列表里
        /// </summary>
        /// <param name="article">作者名</param>
        /// <returns></returns>
        bool isAuthorExist(string literature)
        {
            foreach (var i in this.literatures)
            {
                if (i.ToString().Equals(literature))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 封装模块
        /// </summary>
        /// <param name="name">作者名称</param>
        /// <param name="articles">文章名称列表</param>
        /// <param name="collaborators">合作者名称列表</param>
        public void pkgModule(out string name, out List<string> literatures, out List<string> collaborators)
        {
            name = this.name;
            literatures = this.literatures;
            collaborators = this.collaborators;
        }
    }
}
