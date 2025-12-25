import { use, useMemo } from "react";

export const useSortedThemes = (items, sort) => { 
  const sortedItems = useMemo(() =>{

    if(sort){
      return [...items].sort((a, b) => a[sort].localeCompare(b[sort]))
    }
    return items;
  }, [sort, items]);
  return sortedItems;
}

export const useFilterThemes = (items, filter) => {
    const sortedItems = useSortedThemes(items, filter.sort);
    const sortedAndSearchedThemes = useMemo(() =>{
    return sortedItems.filter(theme => theme.title.toLowerCase().includes(filter.query.toLowerCase()))
  }, [filter.query, sortedItems]);
  return sortedAndSearchedThemes;
}