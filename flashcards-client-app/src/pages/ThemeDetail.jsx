import axios from 'axios';
import React from 'react'
import { useParams } from 'react-router-dom';

const ThemeDetail = () => {

    const params = useParams();
    console.log(params.id);
    const [theme, setTheme] = React.useState(null);

    React.useEffect(() => {
       axios.get(`https://localhost:7172/api/theme/${params.id}`).then(response => setTheme(response.data));
    }, [params.id]);
  return (
    <div>{theme ? theme.title : "Loading..."}</div>
  )
}

export default ThemeDetail