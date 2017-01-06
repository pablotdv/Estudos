import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { FeedSignalR, FeedProxy, FeedClient, FeedServer, SignalRConnectionStatus, ChatMessage, Match, Feed } from '../interfaces';

@Injectable()
export class FeedService {

    currentState = SignalRConnectionStatus.Disconnected;
    connectionState: Observable<SignalRConnectionStatus>;

    setConnectionId: Observable<string>;
    updateMatch: Observable<Match>;    
    addFeed: Observable<Feed>;
    addChatMessage: Observable<ChatMessage>
    
    private connectionStateSubject = new Subject<SignalRConnectionStatus>();

    private setConnectionIdSubject = new Subject<string>();
    private updateMatchSubject = new Subject<Match>();
    private addFeedSubject = new Subject<Feed>();
    private addChatMessageSubject = new Subject<ChatMessage>();

    private server: FeedServer;

    constructor(private http: Http) {
        this.connectionState = this.connectionStateSubject.asObservable();

        this.setConnectionId = this.setConnectionIdSubject.asObservable();
        this.updateMatch = this.updateMatchSubject.asObservable();
        this.addFeed = this.addFeedSubject.asObservable();
        this.addChatMessage = this.addChatMessageSubject.asObservable();
    }

    start(debug: boolean): Observable<SignalRConnectionStatus> {
        
        $.connection.hub.logging = debug;

        let connection = <FeedSignalR>$.connection;

        let feedHub = connection.broadcaster;
        this.server = feedHub.server;

        
        feedHub.client.setConnectionId = id => this.onSetConnectionId(id);


        feedHub.client.updateMatch = match => this.onUpdateMatch(math);


        feedHub.client.addFeed = feed => this.onAddFeed(feed);

        feedHub.client.addChatMessage = chatMessage => this.onAddChatMessage(chatMessage);


        $.connection.hub.start()
            .done(response => this.setConnectionState(SignalRConnectionStatus.Connected))
            .fail(error => this.connectionStateSubject.error(error));

        return this.connectionState;        
    }

    private setConnectionState(connectionState: SignalRConnectionStatus) {
        console.log('connection state change to: ' + connectionState);
        this.currentState = connectionState;
        this.connectionStateSubject.next(connectionState);
    }


    private onSetConnectionId(id: string) {
        this.setConnectionIdSubject.next(id);
    }

    private onUpdateMatch(match: Match) {
        this.updateMatchSubject.next(match);
    }

    private onAddFeed(feed: Feed) {
        console.log(feed);
        this.addFeedSubject.next(feed);
    }

    private onAddChatMessage(chatMessage: ChatMessage) {
        this.addChatMessageSubject.next(chatMessage);        
    }

    
    public subscriveToFeed(matchId: number) {
        this.server.subscribe(matchId);
    }

    public unsubscribeFromFeed(matchId: number) {
        this.server.unsubscribe(matchId);
    }
}