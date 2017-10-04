<?php

class MessageEntity implements JsonSerializable
{
    protected $sender;
    protected $message;
    protected $timestamp;
    protected $channel;

    public function __construct(array $data)
    {
        $this->sender = $data['sender'];
        $this->message = $data['message'];
        $this->timestamp = $data['timestamp'];
        $this->channel = $channel['channel'];
    }

// saving data from post message routes

    public function getTimestamp()
    {
        return $this->timestamp;
    }
    public function getSender()
    {
        //print_r($this->sender);
        return $this->sender;
    }
    public function getMessage()
    {
        return $this->message;
    }
    public function getChannel()
    {
        return $this->channel;
    }
    public function jsonSerialize()
    {
        return [
            'sender' => $this->getSender(),
            'timestamp' => $this->getTimestamp(),
            'message' => $this->getMessage(),
            'channel' => $this->getChannel(),
        ];
    }

}
