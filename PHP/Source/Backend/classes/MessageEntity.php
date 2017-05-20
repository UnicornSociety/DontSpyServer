<?php

class MessageEntity implements JsonSerializable
{
    protected $sender;
    protected $receiver;
    protected $message;
    protected $keyNumber;
    protected $timestamp;

    public function __construct(array $data)
    {
        $this->sender = $data['sender'];
        $this->receiver = $data['receiver'];
        $this->message = $data['message'];
        $this->keyNumber = $data['keyNumber'];
        $this->timestamp = $data['timestamp'];
    }

// saving data from post message routes

    public function getTimestamp()
    {
        return $this->timestamp;
    }
    public function getReceiver()
    {
        return $this->receiver;
    }
    public function getSender()
    {
        //print_r($this->sender);
        return $this->sender;
    }
    public function getKeyNumber()
    {
        return $this->keyNumber;
    }
    public function getMessage()
    {
        return $this->message;
    }
    public function jsonSerialize()
    {
        return [
            'sender' => $this->getSender(),
            'timestamp' => $this->getTimestamp(),
            'message' => $this->getMessage(),
            'keyNumber' => $this->getKeyNumber(),
        ];
    }

}
