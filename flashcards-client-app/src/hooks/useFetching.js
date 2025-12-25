import React from 'react'

const useFetching = () => {
  const [isLoading, setIsLoading] = React.useState(false);
  const [error, setError] = React.useState('');

  const fetching = async (callback, ...args) => {
    setError('');
    try {
      setIsLoading(true);
     await callback(...args);
      
    } catch (e) {
      setError(e.message);
    } finally {
      setIsLoading(false);
    }
  };

  return [fetching, isLoading, error];
}
export default useFetching