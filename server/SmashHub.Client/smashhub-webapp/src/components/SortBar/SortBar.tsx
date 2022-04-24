import { AppBar, Tab, Tabs } from '@material-ui/core';
import { useState } from 'react';
import useSortBarStyles from './SortBar.styles';

function SortBar() {
  const classes = useSortBarStyles();
  const [sortByIndex, setSortByIndex] = useState(0);

  const handleChange = (event: React.ChangeEvent<{}>, value: number) => {
    setSortByIndex(value);
  };

  return (
    <AppBar position="static" className={classes.root}>
      <label className={classes.label}>Sort by:</label>
      <Tabs value={sortByIndex} onChange={handleChange} indicatorColor="primary" textColor="primary">
        <Tab value="Top" label="Top" className={classes.tab} />
        <Tab value="Newest" label="Newest" className={classes.tab} />
        <Tab value="Oldest" label="Oldest" className={classes.tab} />
        <Tab></Tab>
      </Tabs>
    </AppBar>
  );
}

export default SortBar;
