import React from 'react'
import Input from '../UI/input/Input'   
import Select from '../UI/select/Select'

const ThemeFilter = ({filter, setFilter}) => {
  return (
     <div>
        <Input placeholder="Search themes..."
        value={filter.query} onChange={e => setFilter({...filter, query: e.target.value})} />
        <br/>
        <Select value={filter.sort} onChange={selectedSort => setFilter({...filter, sort: selectedSort})} defaultValue="Sort by..." options={[
          {value: 'title', name: 'By Title'},
          {value: 'description', name: 'By Description'}
        ]}/>
      </div>
  )
}

export default ThemeFilter