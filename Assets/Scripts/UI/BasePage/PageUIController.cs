using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageUIController : MonoBehaviour, IPageUIController
{
    [SerializeField] private EnviromentController _enviromentController;
    public IEnviromentController EnviromentController => _enviromentController;

    private List<PageUI> pages;
    private Stack<PageUI> _pagesHistory;

    void Awake()
    {
        pages = new List<PageUI>();
        _pagesHistory = new Stack<PageUI>();
        pages.AddRange(GetComponentsInChildren<PageUI>());
    }

    #region IPageUIController

    /// <summary>
    /// go to page type T where T:Page
    /// </summary>
    /// <typeparam name="T">go to page type T</typeparam>
    public void SwitchPageOn<T>(params object[] parameters) where T : PageUI
    {
        PageUI pageActvate = null;
        foreach (var page in pages)
        {
            if (page.GetType() == typeof(T))
            {
                pageActvate = page;
                _pagesHistory.Push(page);
            }
            else
            {
                page.SetActivate(false);
            }
        }
        pageActvate.SetActivate(true, parameters);
    }

    public void SwitchPageBack()
    {
        print(_pagesHistory.Peek().GetType());
        _pagesHistory.Pop();
        print(_pagesHistory.Peek().GetType());
        PageUI pageActvate = null;
        foreach (var page in pages)
        {
            if (page.GetType() == _pagesHistory.Peek().GetType())
            {
                pageActvate = page;
            }
            else
            {
                page.SetActivate(false);
            }
        }
        pageActvate.ReOpen();
    }

    #endregion IMenuController

    private void DeactivatePages()
    {
        foreach (var page in pages)
        {
            page.SetActivate(false);
        }
    }
}
