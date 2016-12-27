import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { FeedSignalR, FeedProxy, FeedClient, FeedServer, SignalRConnectionStatus, ChatMessage, Match, Feed } from '../interfaces';

@Injectable
export class FeedService {

    currentState = SignalRConnectionStatus.Disconnected;
    connectionState: Observable<SignalRConnectionStatus>;

    setConnectionId: Observable<string>;
    updateMatch: Observable<Match>;
    //addFeed:
}