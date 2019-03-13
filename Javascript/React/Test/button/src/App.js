import React, { Component } from 'react';
import './App.css';
import ClientView from './components/Client/ClientView';

class App extends Component {
  render() {
    return (
      <div className="App">
        <ClientView />
      </div>
    );
  }
}

export default App;
