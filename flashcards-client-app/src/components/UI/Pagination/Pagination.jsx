import React from 'react'
import { useMemo } from 'react'
import { getPagesArray } from '../../../utils/pages.js';
import './Pagination.css'

const Pagination = ({page, changePage, totalPages}) => {
  let pagesArray = useMemo(() => getPagesArray(totalPages), [totalPages, page]);
  return (
    <div className="page_wraper">
        {pagesArray.map(p => 
          <span className={page === p ? "page page_current" : "page"}
          key={p}
          onClick={() => changePage(p)}
          >
            {p}
          </span>
        )}
    </div>
  )
}

export default Pagination