import React, { useEffect, useState } from 'react';
import { GameCard } from './SearchGameCard';
import { searchGames } from '../../modules/gameManager';

const GameSearch = () => {
  const [ games, setGames ] = useState([]);
  const [ criterion, setCriterion ] = useState("");
  const handleGameAdded = () => {
      doSearchGames(criterion)
  }

  const doSearchGames = (criterion) => {
    searchGames(criterion)
      .then((games) => setGames(games));
  };

  useEffect(() => {
    doSearchGames(criterion);
  }, []);

  return (
    <>
      <h1>Search Game</h1>
      <div className="game-search__form">
        <input id="search" value={criterion} onChange={e => setCriterion(e.target.value)}/>
        <button onClick={() => doSearchGames(criterion)}>Search</button>
      </div>
      <div className="game-list">
        {games.map(game =>
          <GameCard 
            key={game.id}
            game={game}
            handleGameAdded={handleGameAdded} />
            
        )}
      </div>
    </>
  );
}

export default GameSearch;