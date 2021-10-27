import React, { useEffect, useState } from 'react';
import { getMyGames } from '../../modules/gameManager';
import { GameCard } from './GameCard';
import "./Game.css"

export const GameList = () => {
    const [ games, setGames] = useState([]);

    useEffect(() => {
        getMyGames().then(games => setGames(games));
    }, []);
    return (
        <>
        <h1>Game List</h1>
        <div className="game-list">
            {games.map(game =>
                <GameCard
                key={game.id}
                game={game}
                />)}
        </div>
        </>
    )
}