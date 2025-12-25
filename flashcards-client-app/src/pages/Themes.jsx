import React, { useEffect, useMemo, useState } from "react"
import axios from "axios"
import { ThemeList } from "../components/theme/ThemeList";
import { ThemeForm } from "../components/theme/ThemeForm";
import ThemeFilter from "../components/theme/ThemeFilter";
import SimpleModal from "../components/UI/SimpleModal/SimpleModal";
import Button from "../components/UI/button/Button";
import { useFilterThemes } from "../hooks/useFilter";
import ThemeService from "../API/ThemeService";
import Loader from "../components/UI/Loader/Loader";
import useFetching from "../hooks/useFetching";
import { getPageCount } from "../utils/pages";
import Pagination from "../components/UI/Pagination/Pagination";

function Themes() {
  const [themes, setThemes] = useState([]);
  const [filter, setFilter] = useState({sort: '', query: ''})
  const [newTheme, setNewTheme] = useState({title:'', description:''})
  const [modalVisible, setModalVisible] = useState(false) 
  const sortedAndSearchedThemes = useFilterThemes(themes, filter);
  const [execute, isLoading, themeError] = useFetching();
  const [totalPages, setTotalPages] = useState(0);
  const [limit, setLimit] = useState(15);
  const [page, setPage] = useState(1);  
  

  useEffect( () => {
    fetchDataThemes(limit, page);
  }, []);


  const changePage = (pageNumber) => {
    setPage(pageNumber);
    fetchDataThemes(limit,  pageNumber);
  }
  const fetchDataThemes = async (limit, page) => {
    execute(async () => {
      const response = await ThemeService.getAll(limit, page);
      setThemes(response.data.themes);
      const totalCount = response.data.totalCount;    
      setTotalPages(getPageCount(totalCount, limit));
    });
  }
  const addNewTheme = async () =>{
    if (!newTheme) return alert("Заповніть назву теми!")
    execute(async () => {
      const response = await ThemeService.create(newTheme);
      setPage(totalPages);
      await fetchDataThemes(limit, totalPages);
      setModalVisible(false);
      setNewTheme({title:'', description:''});
      
    });
    }
  const deleteTheme = async (id) => {
    execute(async () => {
      const response = await ThemeService.delete(id);
      await fetchDataThemes(limit, page);
    });
  }

  return (
    <div className="App">
       {isLoading && (
          <div className="loader-overlay">
              <Loader/>
          </div>
       )} 
         <SimpleModal visible={modalVisible} setVisible={setModalVisible}>  
       <ThemeForm create={addNewTheme} newTheme={newTheme} setNewTheme={setNewTheme}/>
        </SimpleModal>
        <Button onClick={() => setModalVisible(true)}>
          Create new theme
        </Button>
       <hr style={{margin: "1rem 0 1rem 0"}}></hr>
       <ThemeFilter filter={filter} setFilter={setFilter}/>
       {themeError && <div style={{color: "red"}}>{themeError}</div>}
        <ThemeList themes={sortedAndSearchedThemes} title={"Themes"} deleteTheme={deleteTheme}/>
        <Pagination page={page} changePage={changePage} totalPages={totalPages}/>
    </div>
  );
}

export default Themes;
