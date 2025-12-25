import React from 'react'

export const getPageCount = (totalItems, limit) => {
  return Math.ceil(totalItems / limit);
}

export const getPagesArray = (totalPages) => {
  const pagesArray = [];   
    for (let i = 1; i <= totalPages; i++) {
        pagesArray.push(i);
    }
    return pagesArray;
}